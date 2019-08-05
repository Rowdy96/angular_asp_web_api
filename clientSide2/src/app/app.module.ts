import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TestsModule } from './tests/tests.module';
import { TestDetailsModule } from './test-details/test-details.module';

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    TestsModule,
    TestDetailsModule
    
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
