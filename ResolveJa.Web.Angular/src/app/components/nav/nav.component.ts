import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { EmpresaService } from '../../services/empresa.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css'],
  providers: [EmpresaService]
})
export class NavComponent implements OnInit {

  empresaName: any;

  constructor(private activatedRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.empresaName = this.activatedRoute.snapshot.paramMap.get('empresa');
  }

}
