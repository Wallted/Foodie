import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  title = 'app';

  constructor(private _router: Router) {
    
  }
  
  onSwipeRight(evt) {
    var x = this._router.routerState.snapshot.url;
    if(x == '/mealcalendar'){
      this._router.navigateByUrl('home');
    }else if(x == '/home'){
      this._router.navigateByUrl('/data')
    }
  }

  onSwipeLeft(evt) {
    var x = this._router.routerState.snapshot.url;
    if(x == '/home'){
      this._router.navigateByUrl('/mealcalendar');
    }else if(x=='/data'){
      this._router.navigateByUrl('/home');
    }
  }

  onSwipeDown(evt){
    console.log("XD")
    evt.srcEvent.stopPropagation();
    evt.preventDefault();

  }
}
