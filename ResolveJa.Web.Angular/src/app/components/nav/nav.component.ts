import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { EmpresaService } from '../../services/empresa.service';
import { Empresa } from '../../models/empresa.model';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css'],
  providers: [EmpresaService]
})
export class NavComponent implements OnInit {

  empresaUrl: any;

  empresa: Empresa = {
    url: 'undefined',
    nome: 'undefined'
  }

  constructor(
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private service: EmpresaService)
  { }

  ngOnInit(): void {
    this.empresaUrl = this.activatedRoute.snapshot.paramMap.get('empresa');
    this.loadContent();
  }

  loadContent(): void {
    this.service.getByUrl(this.empresaUrl).subscribe(response => {
      this.empresa = response;
    });

    if (this.empresa.url == 'undefined') {
      this.router.navigate(['']);
    }
  }
}
