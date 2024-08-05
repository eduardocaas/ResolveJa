import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { NavComponent } from './components/nav/nav.component';
import { EmpresaComponent } from './components/empresa/empresa.component';

const routes: Routes = [
  {
    path: '', component: NavComponent, children: [
      {path: ':empresa', component: EmpresaComponent}
    ]
  }
];

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class AppRoutingModule { }
