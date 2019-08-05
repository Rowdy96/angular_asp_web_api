import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { TestDetails } from 'src/app/shared/TestDetails';
import { TestDetailsService } from '../test-details.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-add-athlete',
  templateUrl: './add-athlete.component.html',
  styleUrls: ['./add-athlete.component.css']
})
export class AddAthleteComponent implements OnInit {

  athleteForm = new FormGroup({
    name : new FormControl(),
    distance:new FormControl()
  });

  athlete : TestDetails = new TestDetails();

  constructor(private _testDetailService: TestDetailsService,
              private route: ActivatedRoute,
              private router:Router) { }

  ngOnInit() {
    this.athlete.athleteId= 0;
    this.athlete.athleteName=null;
    this.athlete.distance=0;
    this.athlete.MyProperty=null;
    this.athlete.testId= +this.route.snapshot.paramMap.get('id');
    debugger;
  }

  onSubmit(){
    this.athlete.athleteName = this.athleteForm.value.name;
    this.athlete.distance = this.athleteForm.value.distance;
    this._testDetailService.createDetails(this.athlete,this.athlete.testId).subscribe(res=>{
    this.router.navigate(['/testDetails',this.athlete.testId]);  
    });
  }


}
