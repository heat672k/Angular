import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProfileApplicationsComponent } from './profile-applications.component';

describe('ProfileApplicationsComponent', () => {
  let component: ProfileApplicationsComponent;
  let fixture: ComponentFixture<ProfileApplicationsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProfileApplicationsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ProfileApplicationsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
