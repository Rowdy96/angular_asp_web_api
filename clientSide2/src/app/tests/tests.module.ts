import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TestsRoutingModule } from './tests-routing.module';
import { TestDetailsModule } from '../test-details/test-details.module';
import { TestListComponent } from './test-list/test-list.component';
import { CreateTestComponent } from './create-test/create-test.component';
import { DeleteTestComponent } from './delete-test/delete-test.component';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [TestListComponent, CreateTestComponent, DeleteTestComponent],
  imports: [
    CommonModule,
    TestsRoutingModule,
    ReactiveFormsModule,
    TestDetailsModule
  ]
})
export class TestsModule { }
