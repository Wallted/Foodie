import { Component } from '@angular/core';
import { Router, RouterOutlet } from '@angular/router';
import { slideInAnimation } from './animations';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  animations: [
    slideInAnimation
    // animation triggers go here
  ]
})
export class AppComponent {
  title = 'app';

  constructor(private _router: Router) {

  }

  onSwipeRight(evt) {
    var x = this._router.routerState.snapshot.url;
    if (x == '/mealcalendar') {
      this._router.navigateByUrl('home');
    } else if (x == '/home') {
      this._router.navigateByUrl('/data')
    } else return;

    var list = document.getElementsByClassName("floating-buttons");
    [].forEach.call(list, function (el) {
      el.classList.add('invisible');
    });
  }

  onSwipeLeft(evt) {
    var x = this._router.routerState.snapshot.url;
    if (x == '/home') {
      this._router.navigateByUrl('/mealcalendar');
    } else if (x == '/data') {
      this._router.navigateByUrl('/home');
    }else return
   
    var list = document.getElementsByClassName("floating-buttons");
    [].forEach.call(list, function (el) {
      el.classList.add('invisible');
    });
  }

  onSwipeDown(evt) {
    evt.srcEvent.stopPropagation();
    evt.preventDefault();
  }

  prepareRoute(outlet: RouterOutlet) {
    // console.log(outlet && outlet.activatedRouteData && outlet.activatedRouteData['animation'])
    return outlet && outlet.activatedRouteData && outlet.activatedRouteData['animation'];
  }
}
