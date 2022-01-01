/// <reference path="../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { ViewCvComponent } from './view-cv.component';

let component: ViewCvComponent;
let fixture: ComponentFixture<ViewCvComponent>;

describe('ViewCv component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ ViewCvComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(ViewCvComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});