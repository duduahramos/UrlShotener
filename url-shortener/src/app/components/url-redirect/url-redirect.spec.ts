import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UrlRedirectComponent } from './url-redirect';

describe('UrlRedirect', () => {
  let component: UrlRedirectComponent;
  let fixture: ComponentFixture<UrlRedirectComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [UrlRedirectComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UrlRedirectComponent);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
