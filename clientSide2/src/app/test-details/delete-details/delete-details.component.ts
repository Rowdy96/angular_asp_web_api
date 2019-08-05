import { Component, OnInit } from '@angular/core';
import { TestDetails } from 'src/app/shared/TestDetails';
import { Router, ActivatedRoute } from '@angular/router';
import { TestDetailsService } from '../test-details.service';
import { Location } from '@angular/common';

@Component({
  selector: 'app-delete-details',
  templateUrl: './delete-details.component.html',
  styleUrls: ['./delete-details.component.css']
})
export class DeleteDetailsComponent implements OnInit {

  testDetails : TestDetails;
  constructor(private router : Router,
              private location : Location, 
              private _testDetailsService : TestDetailsService,
              private route:ActivatedRoute) { }

  ngOnInit() {
  }

  back(){
    this.location.back();
  }

  onClick(){
    const id = +this.route.snapshot.paramMap.get('id');
    this._testDetailsService.getTestDetailsById(id).subscribe(res=>{
      this.testDetails = res;
    })
    this._testDetailsService.deleteDetails(id).subscribe(res =>{
      this.router.navigate(['/testDetails',this.testDetails.testId]);
    });
  }

}
