import { Component, OnInit,Input } from '@angular/core';
import {SharedService} from 'src/app/shared.service';

@Component({
  selector: 'app-add-edit-sub',
  templateUrl: './add-edit-sub.component.html',
  styleUrls: ['./add-edit-sub.component.css']
})
export class AddEditSubComponent implements OnInit {

  constructor(private service:SharedService) { }

  @Input() sub:any;
  Name:string;
  Description:string;

  ngOnInit(): void {
    this.Name=this.sub.Name;
    this.Description=this.sub.Description;
  }

  addSubject(){
    var val = {Name:this.Name,
      Description:this.Description};
    this.service.addSub(val).subscribe(res=>{
      alert(res.toString());
    });
  }

  updateSubject(){
    var val = {Name:this.Name,
      Description:this.Description};
    this.service.updateSub(val).subscribe(res=>{
    alert(res.toString());
    });
  }


}
