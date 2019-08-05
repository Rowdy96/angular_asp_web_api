import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TestDetailsListComponent } from './test-details-list/test-details-list.component';
import { EditDetailsComponent } from './edit-details/edit-details.component';
import { AddAthleteComponent } from './add-athlete/add-athlete.component';
import { DeleteDetailsComponent } from './delete-details/delete-details.component';
import { DeleteTestComponent } from '../tests/delete-test/delete-test.component';


const routes: Routes = [
  {
    path: '',
    component:TestDetailsListComponent
  },
  {
    path: 'testDetails/:id',
    component:TestDetailsListComponent
  },
  {
    path: 'details/:id',
    component:EditDetailsComponent
  },
  {
    path: 'addAthlete/:id',
    component:AddAthleteComponent
  },
  {
    path: 'deleteAthlete/:id',
    component:DeleteDetailsComponent
  },
  {
    path:'deleteTest/:id',
    component:DeleteTestComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TestDetailsRoutingModule { }
