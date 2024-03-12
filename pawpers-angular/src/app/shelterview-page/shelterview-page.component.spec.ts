import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShelterviewPageComponent } from './shelterview-page.component';

describe('ShelterviewPageComponent', () => {
  let component: ShelterviewPageComponent;
  let fixture: ComponentFixture<ShelterviewPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShelterviewPageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ShelterviewPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
