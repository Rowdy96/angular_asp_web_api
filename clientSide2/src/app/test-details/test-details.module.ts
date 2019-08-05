import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TestDetailsRoutingModule } from './test-details-routing.module';
import { TestDetailsListComponent } from './test-details-list/test-details-list.component';
import { EditDetailsComponent } from './edit-details/edit-details.component';
import { ReactiveFormsModule } from '@angular/forms';
import { AddAthleteComponent } from './add-athlete/add-athlete.component';
import { DeleteDetailsComponent } from './delete-details/delete-details.component';

@NgModule({
  declarations: [
    TestDetailsListComponent, 
    EditDetailsComponent, 
    AddAthleteComponent, 
    DeleteDetailsComponent
  ],
  imports: [
    CommonModule,
    TestDetailsRoutingModule,
    ReactiveFormsModule,
    
  ]
})
export class TestDetailsModule { }
