import { Component, Inject, OnInit } from '@angular/core';
import { MatBottomSheetRef, MAT_BOTTOM_SHEET_DATA } from '@angular/material/bottom-sheet';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { first } from 'rxjs';


@Component({
  selector: 'app-mybottom-sheet',
  templateUrl: './mybottom-sheet.component.html',
  styleUrls: ['./mybottom-sheet.component.css']
})
export class MybottomSheetComponent implements OnInit {

  constructor(
    private _bottomSheetRef: MatBottomSheetRef<MybottomSheetComponent>,
    @Inject(MAT_BOTTOM_SHEET_DATA) public data: {employee : any},

    private toastr: ToastrService,
    private router: Router
    ) { }

  ngOnInit(): void {

  }
    tasks : any;

    allComplete: boolean = false;




    }







  

