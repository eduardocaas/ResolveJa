import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
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

  constructor(private activatedRoute: ActivatedRoute, private service: EmpresaService) { }

  ngOnInit(): void {
    this.empresaUrl = this.activatedRoute.snapshot.paramMap.get('empresa');
    this.getByUrl();
  }

  getByUrl() {
    this.service.getByUrl(this.empresaUrl).subscribe(response => {
      this.empresa = response;
    })
  }
}
