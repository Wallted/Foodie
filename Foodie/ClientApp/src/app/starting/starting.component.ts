import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthorizeService } from 'src/api-authorization/authorize.service';

@Component({
  selector: 'app-starting',
  templateUrl: './starting.component.html',
  styleUrls: ['./starting.component.css']
})
export class StartingComponent implements OnInit {

  constructor(private router: Router, private autService: AuthorizeService) { }

  ngOnInit() {
    this.autService.isAuthenticated().subscribe(result => {
      if (result === true) {
        this.router.navigateByUrl('home')
      }
    });
  }

}
