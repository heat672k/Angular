import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProfileOffersComponent } from './profile-offers.component';

describe('ProfileOffersComponent', () => {
  let component: ProfileOffersComponent;
  let fixture: ComponentFixture<ProfileOffersComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProfileOffersComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ProfileOffersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
