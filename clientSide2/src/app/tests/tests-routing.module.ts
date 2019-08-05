import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TestListComponent } from './test-list/test-list.component';
import { CreateTestComponent } from './create-test/create-test.component';
import { TestDetailsListComponent } from '../test-details/test-details-list/test-details-list.component';



const routes: Routes = [
  {
    path: '',
    component:TestListComponent
  },
  {
    path: 'create',
    component:CreateTestComponent
  },
  {
    path: 'testDetails/:id',
    component:TestDetailsListComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TestsRoutingModule { }
