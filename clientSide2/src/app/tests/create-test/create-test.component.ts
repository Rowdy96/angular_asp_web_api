import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { Test } from 'src/app/shared/Test';
import { Router } from '@angular/router';
import { TestService } from '../test.service';

@Component({
  selector: 'app-create-test',
  templateUrl: './create-test.component.html',
  styleUrls: ['./create-test.component.css']
})
export class CreateTestComponent implements OnInit {

  testForm = new FormGroup({
    testType : new FormControl(''),
    date: new FormControl('')
    });
  
    test : Test = new Test();
    testType: string[];
    constructor(private Service : TestService,private _route: Router ) { }
  
    ngOnInit() {
      this.test.testId = 0;
      this.test.date = null;
      this.test.numOfParticipants = 0;
      this.test.testType="";
    }
  
    onSubmit(){
      this.test.date=this.testForm.value.date;
      this.test.testType=this.testForm.value.testType;
      this.AddTest(this.test);
    }
  
    AddTest(test : Test):void {
      this.Service.AddNewTest(test).subscribe(res=>{
        this._route.navigate(['']);
      });
    }
}
