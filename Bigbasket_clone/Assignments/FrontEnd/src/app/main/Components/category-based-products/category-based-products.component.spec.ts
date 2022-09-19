import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CategoryBasedProductsComponent } from './category-based-products.component';

describe('CategoryBasedProductsComponent', () => {
  let component: CategoryBasedProductsComponent;
  let fixture: ComponentFixture<CategoryBasedProductsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CategoryBasedProductsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CategoryBasedProductsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
