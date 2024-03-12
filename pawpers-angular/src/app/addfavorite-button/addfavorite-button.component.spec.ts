import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddfavoriteButtonComponent } from './addfavorite-button.component';

describe('AddfavoriteButtonComponent', () => {
  let component: AddfavoriteButtonComponent;
  let fixture: ComponentFixture<AddfavoriteButtonComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddfavoriteButtonComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddfavoriteButtonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
