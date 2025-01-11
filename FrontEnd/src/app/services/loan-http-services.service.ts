import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { calculateLoanInterestsModel } from '../dto/calculate-loan-interests.model';
import { Observable } from 'rxjs';

@Injectable()
export class LoanHttpServicesService {

  constructor(private http: HttpClient) { }


  calculateLoanInterests(data: calculateLoanInterestsModel): Observable<number> {
    return this.http
    .get<number>(
      `https://localhost:7266/api/Loan/CalculateLoanInterests/${data.userId}?amount=${data.loanAmount}&periodInMonth=${data.loanPeriodInMonth}`
    );
  }
}
