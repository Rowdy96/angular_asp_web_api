import { Component, OnInit } from '@angular/core';
import { TestDetails } from 'src/app/shared/TestDetails';
import { FormGroup, FormControl } from '@angular/forms';
import { TestDetailsService } from '../test-details.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Location } from '@angular/common';

@Component({
  selector: 'app-edit-details',
  templateUrl: './edit-details.component.html',
  styleUrls: ['./edit-details.component.css']
})
export class EditDetailsComponent implements OnInit {

  testDetails : TestDetails ;
  EditForm = new FormGroup({
    athleteName : new FormControl(),
    distance : new FormControl()
  });

  constructor(private _testDetailService : TestDetailsService,
              private _route: ActivatedRoute,
              private _router : Router
              ) 
              {
                this.testDetails = new TestDetails();
              }

  ngOnInit() {
    this.getDetails();
  }

  getDetails(): void {
    const id = +this._route.snapshot.paramMap.get('id');

    this._testDetailService.getTestDetailsById(id).subscribe(testDetails =>
      {
        this.testDetails = testDetails;
        debugger;
      });

    this.EditForm.patchValue({
      athleteName : this.testDetails.athleteName,
      distance : this.testDetails.distance
    });  

    debugger;
  }

  update(){
    this.testDetails.athleteName = this.EditForm.value.athleteName;
    this.testDetails.distance = this.EditForm.value.distance;
    console.log(this.testDetails);
    debugger;
    this._testDetailService.updateDetails(this.testDetails.athleteId,this.testDetails).subscribe(res =>{
     this._router.navigate(['/testDetails',this.testDetails.testId]);
    });
  }

}
