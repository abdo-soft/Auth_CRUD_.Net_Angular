import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MybottomSheetComponent } from './mybottom-sheet.component';

describe('MybottomSheetComponent', () => {
  let component: MybottomSheetComponent;
  let fixture: ComponentFixture<MybottomSheetComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MybottomSheetComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MybottomSheetComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
