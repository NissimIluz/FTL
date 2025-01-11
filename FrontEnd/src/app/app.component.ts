import { Component  } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { LoanHttpServicesService } from './services/loan-http-services.service';
import { LoanDetailsDialogComponent } from './components/loan-details-dialog/loan-details-dialog.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { calculateLoanInterestsModel } from './dto/calculate-loan-interests.model';
import { MatDialogModule} from '@angular/material/dialog';


@Component({
  selector: 'app-root',
  standalone: true,
  imports: [ CommonModule, FormsModule, ReactiveFormsModule, MatDialogModule ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
  providers: [ LoanHttpServicesService],
})
export class AppComponent {
  loanForm: FormGroup;

  constructor(private fb: FormBuilder, private loanHttpServicesService: LoanHttpServicesService, private dialog: MatDialog) {
    this.loanForm = this.fb.group({
      userId: ['', [Validators.required, Validators.pattern(/^([0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12})$/)]],
      loanAmount: ['', [Validators.required, Validators.min(1)]],
      loanPeriodInMonth: ['', [Validators.required, Validators.min(1)]]
    });
  }



  onSubmit() {
    if (this.loanForm.valid) {
      const loanData: calculateLoanInterestsModel = this.loanForm.value;
      this.loanHttpServicesService.calculateLoanInterests(loanData).subscribe(
        totalPayment => {
          this.openDialog({loanAmount: loanData.loanAmount, totalPayment});
        },
        error => {
          console.error('Error fetching loan details:', error);
        }
      );
    } else {
      alert('Please fill all required fields with valid values.');
    }
  }

  openDialog(data: any) {
    this.dialog.open(LoanDetailsDialogComponent, {
      data: data
    });
  }
}

