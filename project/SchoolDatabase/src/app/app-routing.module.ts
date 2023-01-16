import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {StudentComponent} from './student/student.component';
import {SubjectComponent} from './subject/subject.component';


const routes: Routes = [
  {path:'student',component:StudentComponent},
  {path:'subject',component:SubjectComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
