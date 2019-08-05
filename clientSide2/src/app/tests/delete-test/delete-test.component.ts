import { Component, OnInit } from '@angular/core';
import { TestService } from '../test.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Location } from '@angular/common';

@Component({
  selector: 'app-delete-test',
  templateUrl: './delete-test.component.html',
  styleUrls: ['./delete-test.component.css']
})
export class DeleteTestComponent implements OnInit {

  constructor(private location:Location,
              private testService : TestService,
              private route : ActivatedRoute,
              private router : Router) { }

  ngOnInit() {
  }

  back(){
    this.location.back();
  }  

  onClick(){
  const id = +this.route.snapshot.paramMap.get('id');
  debugger;
  this.testService.DeleteTest(id).subscribe(res=>{
  this.router.navigate(['']);
  });
  }

}
