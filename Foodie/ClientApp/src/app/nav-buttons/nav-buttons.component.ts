import { Component, OnInit } from '@angular/core';
import { Router, NavigationEnd } from '@angular/router';
import { filter } from 'rxjs/operators';
import { AuthorizeService } from 'src/api-authorization/authorize.service';

@Component({
  selector: 'app-nav-buttons',
  templateUrl: './nav-buttons.component.html',
  styleUrls: ['./nav-buttons.component.css']
})
export class NavButtonsComponent implements OnInit {

  constructor(private router: Router, private authorizeService: AuthorizeService) { }

  dataButtonChecked = false;
  homeButtonChecked = false;
  mealsButtonChecked = false;
  isAuthorized = false;

  ngOnInit() {
    this.authorizeService.isAuthenticated().subscribe(result=> this.isAuthorized=result);

    this.router.events.pipe(
      filter(event => event instanceof NavigationEnd)
    ).subscribe((event: NavigationEnd) => {
      if(event.url == "/data"){
        this.dataButtonChecked=true;
        this.homeButtonChecked=false;
        this.mealsButtonChecked=false;
      }else if(event.url == "/home"){
        this.dataButtonChecked=false;
        this.homeButtonChecked=true;
        this.mealsButtonChecked=false;
      }else if(event.url == "/mealcalendar"){
        this.dataButtonChecked=false;
        this.homeButtonChecked=false;
        this.mealsButtonChecked=true;
      }
      if(event.url == "/products"){
        this.dataButtonChecked=false;
        this.homeButtonChecked=false;
        this.mealsButtonChecked=false;
      }
      // console.log(event.url)
    });
  };
}