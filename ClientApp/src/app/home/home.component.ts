import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthorizeService } from 'src/api-authorization/authorize.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  
  constructor(private authorizeService: AuthorizeService, private router: Router) { }

  ngOnInit(): void {
    this.authorizeService.isAuthenticated().subscribe(isAuthenticated => {
      if (isAuthenticated) {
        this.router.navigateByUrl('/dashboard');
      }
    });
  }
}
