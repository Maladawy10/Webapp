import { Component ,OnInit } from '@angular/core';
import {Input} from '@angular/core';
import {SharedService} from 'src/app/shared.service';
@Component({
  selector: 'app-add-edit-st',
  templateUrl: './add-edit-st.component.html',
  styleUrls: ['./add-edit-st.component.css']
})
export class AddEditStComponent implements OnInit{

  constructor(private service:SharedService){}

  @Input() st:any='';
  SSN:number;
  Name:string;
  Birthdate:string;
  Gender:string;

  ngOnInit():void{
    this.SSN=this.st.SSN;
    this.Name=this.st.Name;
    this.Birthdate=this.st.Birthdate;
    this.Gender=this.st.Gender;
  }

  addStudent(){
    var val = {SSN:this.SSN,
                DepartmentName:this.Name,Birthdate:this.Birthdate,Gender:this.Gender};
    this.service.addSt(val).subscribe(res=>{
      alert(res.toString());
    });
  }

  updateStudent(){
    var val = {SSN:this.SSN,
      DepartmentName:this.Name,Birthdate:this.Birthdate,Gender:this.Gender};
this.service.updateSt(val).subscribe(res=>{
alert(res.toString());});
  }
}
