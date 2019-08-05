import { Component, OnInit } from '@angular/core';
import { TestDetails } from 'src/app/shared/TestDetails';
import { TestDetailsService } from '../test-details.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Test } from 'src/app/shared/Test';
import { TestService } from 'src/app/tests/test.service';

@Component({
  selector: 'app-test-details-list',
  templateUrl: './test-details-list.component.html',
  styleUrls: ['./test-details-list.component.css']
})
export class TestDetailsListComponent implements OnInit {

  public Test: Test = new Test();
  public TestDetails : TestDetails[];
  public Id :number;
  constructor(private _testDetailService : TestDetailsService ,
              private route : ActivatedRoute,
              private router : Router,
              private _testService: TestService
            ) { }

  ngOnInit() {
    this.getAllTestDetails();
  }

  getAllTestDetails(): void{
    const id=+this.route.snapshot.paramMap.get('id');
    this.Id = id;
    this._testDetailService.getTestDetails(id).subscribe(testDetails => 
      {
        this.TestDetails = testDetails;
      });

    this._testService.getTestById(id).subscribe(Test =>{
      this.Test = Test;
    })
  }

  onClick(id : number){
    this.router.navigate(['/details',id]);
  }


}
