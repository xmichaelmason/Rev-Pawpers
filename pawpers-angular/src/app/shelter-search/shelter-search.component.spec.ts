import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShelterSearchComponent } from './shelter-search.component';

describe('ShelterSearchComponent', () => {
  let component: ShelterSearchComponent;
  let fixture: ComponentFixture<ShelterSearchComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShelterSearchComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ShelterSearchComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
