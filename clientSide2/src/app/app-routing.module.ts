import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


const routes: Routes = [
  {
    path:'',
    loadChildren: () => import('./tests/tests.module').then(mod=>
      mod.TestsModule)
  },
  {
    path : 'details',
    loadChildren: () => import('./test-details/test-details.module').then(mod=>
      mod.TestDetailsModule)
  },
  {
    path: '',
    redirectTo: '',
    pathMatch: 'full'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
