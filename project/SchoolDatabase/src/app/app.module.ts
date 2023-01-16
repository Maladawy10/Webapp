import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { StudentComponent } from './student/student.component';
import { ShowDeleteStComponent } from './student/show-delete-st/show-delete-st.component';
import { AddEditStComponent } from './student/add-edit-st/add-edit-st.component';
import { SubjectComponent } from './subject/subject.component';
import { ShowDeleteSubComponent } from './subject/show-delete-sub/show-delete-sub.component';
import { AddEditSubComponent } from './subject/add-edit-sub/add-edit-sub.component';
import { SharedService } from './shared.service';
import {HttpClientModule} from '@angular/common/http';
import {FormsModule,ReactiveFormsModule} from '@angular/forms';
@NgModule({
  declarations: [
    AppComponent,
    StudentComponent,
    ShowDeleteStComponent,
    AddEditStComponent,
    SubjectComponent,
    ShowDeleteSubComponent,
    AddEditSubComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [SharedService],
  bootstrap: [AppComponent]
})
export class AppModule { }
