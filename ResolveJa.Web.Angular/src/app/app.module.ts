import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';

import { HttpClientModule } from '@angular/common/http';

import { NavComponent } from './components/nav/nav.component';
import { EmpresaComponent } from './components/empresa/empresa.component';

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    EmpresaComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
