import { Component, OnInit } from '@angular/core';
import {RouterModule} from '@angular/router';
import { EmpService } from 'src/app/_services/emp.service';
import { Emp } from 'src/app/_models/emp';
import { first } from 'rxjs';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {


  employees!: Emp[];
  totalrow: number = 0;

  constructor(private empService: EmpService) { }


  ngOnInit(): void {
    this.loadEmployee();
  }

  loadEmployee() {
    this.empService.getAll().pipe(first())
      .subscribe(d => {
        console.log("Employee Load",d)
        this.employees = d;
        this.totalrow = d.length;
      });
  }

  delete(emp: Emp) {
    console.log("Employee delete",emp)
    this.empService.delete(emp.EmpId).pipe(first())
      .subscribe(() => {
        this.loadEmployee();
      })
  }

}

