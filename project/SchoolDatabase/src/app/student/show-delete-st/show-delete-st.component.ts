import { Component, OnInit } from '@angular/core';
import {SharedService} from 'src/app/shared.service'
@Component({
  selector: 'app-show-delete-st',
  templateUrl: './show-delete-st.component.html',
  styleUrls: ['./show-delete-st.component.css']
})
export class ShowDeleteStComponent implements OnInit{

  constructor(private service:SharedService){

  }
  StudentData:any=[];
  ngOnInit():void{this.refreshStData();}

  ModalTitle:string;
  st:any;
  ActivateAddEditStComp:boolean=false;
  
  addClick(){
    this.st={
      SSN:0,Name:"",
      Birthdate:"",
      Gender:''

    }
    this.ModalTitle="Add Student";
    this.ActivateAddEditStComp=true;
  }

  editClick(item){
    this.st=item;
    this.ModalTitle="Edit Student";
    this.ActivateAddEditStComp=true;
  }

  deleteClick(item){
    if(confirm('Are you sure??')==true){
      this.service.deleteSt(item.SSN).subscribe(data=>{
        alert(data.toString());
        this.refreshStData();
      })
    }
  }

  closeClick(){
    this.ActivateAddEditStComp=false;
    this.refreshStData();
  }

  refreshStData(){
    this.service.getStData().subscribe(data=>{
      this.StudentData=data;
    });
  }

}
