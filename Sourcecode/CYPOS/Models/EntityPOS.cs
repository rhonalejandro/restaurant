using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace cypos.Models
{
    public partial class EntityPOS : DbContext
    {
        public EntityPOS()
            : base("name=Entities")
        {
        }

        public virtual DbSet<tbl_Category> tbl_Category { get; set; }
        public virtual DbSet<tbl_Customer> tbl_Customer { get; set; }
        public virtual DbSet<tbl_DuePayment> tbl_DuePayment { get; set; }
        public virtual DbSet<tbl_Expense> tbl_Expense { get; set; }
        public virtual DbSet<tbl_ExpenseGroup> tbl_ExpenseGroup { get; set; }
        public virtual DbSet<tbl_HoldNo> tbl_HoldNo { get; set; }
        public virtual DbSet<tbl_InvoiceDetail> tbl_InvoiceDetail { get; set; }
        public virtual DbSet<tbl_InvoiceHeader> tbl_InvoiceHeader { get; set; }
        public virtual DbSet<tbl_InvoiceNo> tbl_InvoiceNo { get; set; }
        public virtual DbSet<tbl_Item> tbl_Item { get; set; }
        public virtual DbSet<tbl_ItemNo> tbl_ItemNo { get; set; }
        public virtual DbSet<tbl_KotNo> tbl_KotNo { get; set; }
        public virtual DbSet<tbl_Modifier> tbl_Modifier { get; set; }
        public virtual DbSet<tbl_PaymentType> tbl_PaymentType { get; set; }
        public virtual DbSet<tbl_Purchase> tbl_Purchase { get; set; }
        public virtual DbSet<tbl_ReturnItem> tbl_ReturnItem { get; set; }
        public virtual DbSet<tbl_Supplier> tbl_Supplier { get; set; }
        public virtual DbSet<tbl_TableLocation> tbl_TableLocation { get; set; }
        public virtual DbSet<tbl_Tables> tbl_Tables { get; set; }
        public virtual DbSet<tbl_TempDetail> tbl_TempDetail { get; set; }
        public virtual DbSet<tbl_TempHeader> tbl_TempHeader { get; set; }
        public virtual DbSet<tbl_TerminalLocation> tbl_TerminalLocation { get; set; }
        public virtual DbSet<tbl_User> tbl_User { get; set; }
        public virtual DbSet<tbl_UserLogs> tbl_UserLogs { get; set; }
        public virtual DbSet<tbl_Company> tbl_Company { get; set; }
        public virtual DbSet<tbl_CustomerCredit> tbl_CustomerCredit { get; set; }
        public virtual DbSet<vw_CustCreditReport> vw_CustCreditReport { get; set; }
        public virtual DbSet<vw_CustomerCredit> vw_CustomerCredit { get; set; }
        public virtual DbSet<vw_General_Ledger> vw_General_Ledger { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tbl_Category>()
                .Property(e => e.category_name)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Customer>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Customer>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Customer>()
                .Property(e => e.city)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Customer>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Customer>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_DuePayment>()
                .Property(e => e.payment_date)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_DuePayment>()
                .Property(e => e.payment_type)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_DuePayment>()
                .Property(e => e.customer_id)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Expense>()
                .Property(e => e.expense_date)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Expense>()
                .Property(e => e.reference_no)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Expense>()
                .Property(e => e.note)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Expense>()
                .Property(e => e.created_by)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_ExpenseGroup>()
                .Property(e => e.group_name)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_HoldNo>()
                .Property(e => e.hold_id)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_InvoiceDetail>()
                .Property(e => e.invoice_date)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_InvoiceDetail>()
                .Property(e => e.invoice_time)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_InvoiceDetail>()
                .Property(e => e.item_code)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_InvoiceHeader>()
                .Property(e => e.invoice_no)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_InvoiceHeader>()
                .Property(e => e.invoice_date)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_InvoiceHeader>()
                .Property(e => e.invoice_time)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_InvoiceHeader>()
                .Property(e => e.customer_id)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_InvoiceHeader>()
                .Property(e => e.payment_type)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_InvoiceHeader>()
                .Property(e => e.user_name)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_InvoiceNo>()
                .Property(e => e.invoice_no)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Item>()
                .Property(e => e.item_code)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Item>()
                .Property(e => e.image_name)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Item>()
                .Property(e => e.update_by)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_ItemNo>()
                .Property(e => e.item_no)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_KotNo>()
                .Property(e => e.kot_no)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Modifier>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Modifier>()
                .Property(e => e.price_method)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Modifier>()
                .Property(e => e.item_code)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Modifier>()
                .Property(e => e.back_color)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Modifier>()
                .Property(e => e.fore_color)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_PaymentType>()
                .Property(e => e.payment_type)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Purchase>()
                .Property(e => e.purchase_date)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Purchase>()
                .Property(e => e.ref_no)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Purchase>()
                .Property(e => e.purchase_type)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_ReturnItem>()
                .Property(e => e.return_date)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_ReturnItem>()
                .Property(e => e.invoice_no)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_ReturnItem>()
                .Property(e => e.customer_id)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_ReturnItem>()
                .Property(e => e.item_code)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_ReturnItem>()
                .Property(e => e.item_name)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Supplier>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Supplier>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Supplier>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Supplier>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_TableLocation>()
                .Property(e => e.location_name)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Tables>()
                .Property(e => e.table_name)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_TempDetail>()
                .Property(e => e.invoice_date)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_TempDetail>()
                .Property(e => e.invoice_time)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_TempDetail>()
                .Property(e => e.item_code)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_TempDetail>()
                .Property(e => e.qty)
                .HasPrecision(18, 0);

            modelBuilder.Entity<tbl_TempHeader>()
                .Property(e => e.invoice_date)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_TempHeader>()
                .Property(e => e.invoice_time)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_TempHeader>()
                .Property(e => e.kot_no)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_TempHeader>()
                .Property(e => e.customer_id)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_TempHeader>()
                .Property(e => e.payment_type)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_TempHeader>()
                .Property(e => e.user_name)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_TempHeader>()
                .Property(e => e.status)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_TerminalLocation>()
                .Property(e => e.CompanyName)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_TerminalLocation>()
                .Property(e => e.Branchname)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_TerminalLocation>()
                .Property(e => e.Location)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_TerminalLocation>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_TerminalLocation>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_TerminalLocation>()
                .Property(e => e.Web)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_TerminalLocation>()
                .Property(e => e.VAT)
                .HasPrecision(18, 3);

            modelBuilder.Entity<tbl_TerminalLocation>()
                .Property(e => e.Dis)
                .HasPrecision(18, 3);

            modelBuilder.Entity<tbl_TerminalLocation>()
                .Property(e => e.VATRegiNo)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_TerminalLocation>()
                .Property(e => e.Shopid)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_TerminalLocation>()
                .Property(e => e.Footermsg)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_User>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_User>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_User>()
                .Property(e => e.contact)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_User>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_User>()
                .Property(e => e.dob)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_User>()
                .Property(e => e.user_name)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_User>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_User>()
                .Property(e => e.user_type)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_User>()
                .Property(e => e.image_name)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_UserLogs>()
                .Property(e => e.user_name)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_UserLogs>()
                .Property(e => e.log_type)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_UserLogs>()
                .Property(e => e.log_time)
                .HasPrecision(0);

            modelBuilder.Entity<tbl_Company>()
                .Property(e => e.company_name)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Company>()
                .Property(e => e.company_address)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Company>()
                .Property(e => e.company_phone)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Company>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Company>()
                .Property(e => e.web)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Company>()
                .Property(e => e.tax_no)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Company>()
                .Property(e => e.footer_message)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Company>()
                .Property(e => e.logo)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Company>()
                .Property(e => e.tax_type)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Company>()
                .Property(e => e.tax1_name)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Company>()
                .Property(e => e.tax2_name)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_CustomerCredit>()
                .Property(e => e.OrderID)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_CustomerCredit>()
                .Property(e => e.Date)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_CustomerCredit>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<vw_CustCreditReport>()
                .Property(e => e.Date)
                .IsUnicode(false);

            modelBuilder.Entity<vw_CustCreditReport>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<vw_CustCreditReport>()
                .Property(e => e.OrderID)
                .IsUnicode(false);

            modelBuilder.Entity<vw_CustCreditReport>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<vw_CustomerCredit>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<vw_CustomerCredit>()
                .Property(e => e.Mobile)
                .IsUnicode(false);

            modelBuilder.Entity<vw_CustomerCredit>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<vw_CustomerCredit>()
                .Property(e => e.EmailAddress)
                .IsUnicode(false);

            modelBuilder.Entity<vw_CustomerCredit>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<vw_CustomerCredit>()
                .Property(e => e.PeopleType)
                .IsUnicode(false);

            modelBuilder.Entity<vw_General_Ledger>()
                .Property(e => e.Date)
                .IsUnicode(false);

            modelBuilder.Entity<vw_General_Ledger>()
                .Property(e => e.Sales)
                .HasPrecision(38, 2);

            modelBuilder.Entity<vw_General_Ledger>()
                .Property(e => e.Return)
                .HasPrecision(38, 2);
        }
    }
}
