import { Component, OnInit } from '@angular/core';
import { TestService } from '../test.service';
import { Test } from 'src/app/shared/Test';
import { Router } from '@angular/router';

@Component({
  selector: 'app-test-list',
  templateUrl: './test-list.component.html',
  styleUrls: ['./test-list.component.css']
})
export class TestListComponent implements OnInit {

  testList : Test[];
  constructor(private service: TestService ,private router : Router) { }

  ngOnInit() {
    this.getTests();
    debugger;
  }

  getTests() : void{
    this.service.getAllTest().subscribe(res=>{
      this.testList = res;
    })
  }

  onClick(id : number){
    this.router.navigate(['/testDetails',id]);
  }

}
