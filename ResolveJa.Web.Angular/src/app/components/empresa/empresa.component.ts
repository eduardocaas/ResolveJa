import { Component } from '@angular/core';
import { Empresa } from '../../models/empresa.model';
import { ActivatedRoute, Router } from '@angular/router';
import { EmpresaService } from '../../services/empresa.service';

@Component({
  selector: 'app-empresa',
  templateUrl: './empresa.component.html',
  styleUrls: ['./empresa.component.css']
})
export class EmpresaComponent {

  empresaUrl: any;

  empresa: Empresa = {
    url: 'undefined',
    nome: 'undefined'
  }

  constructor(
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private service: EmpresaService) { }

  ngOnInit(): void {
    this.empresaUrl = this.activatedRoute.snapshot.paramMap.get('empresa');

  }

}
