import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VendItemsComponent } from './vend-items.component';

describe('VendItemsComponent', () => {
  let component: VendItemsComponent;
  let fixture: ComponentFixture<VendItemsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [VendItemsComponent]
    });
    fixture = TestBed.createComponent(VendItemsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
