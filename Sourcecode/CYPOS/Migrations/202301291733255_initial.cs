namespace cypos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_Category",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        category_name = c.String(unicode: false),
                        sort_order = c.Long(),
                        back_color = c.Long(),
                        fore_color = c.Long(),
                        active = c.Boolean(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.tbl_Company",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        company_name = c.String(unicode: false),
                        company_address = c.String(unicode: false),
                        company_phone = c.String(unicode: false),
                        email = c.String(unicode: false),
                        web = c.String(unicode: false),
                        tax_no = c.String(unicode: false),
                        footer_message = c.String(unicode: false),
                        logo = c.String(unicode: false),
                        log_date = c.DateTime(),
                        tax_type = c.String(unicode: false),
                        tax1_name = c.String(unicode: false),
                        tax1_rate = c.Decimal(precision: 18, scale: 2),
                        tax2_name = c.String(unicode: false),
                        tax2_rate = c.Decimal(precision: 18, scale: 2),
                        cal_method = c.Int(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.tbl_Customer",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        name = c.String(unicode: false),
                        address = c.String(unicode: false),
                        city = c.String(unicode: false),
                        phone = c.String(unicode: false),
                        email = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.tbl_CustomerCredit",
                c => new
                    {
                        ID = c.Long(nullable: false),
                        CustID = c.Long(nullable: false),
                        OrderID = c.String(maxLength: 250, unicode: false),
                        Date = c.String(maxLength: 150, unicode: false),
                        Credit = c.Decimal(precision: 18, scale: 2),
                        Description = c.String(maxLength: 250, unicode: false),
                        Logtime = c.DateTime(),
                    })
                .PrimaryKey(t => new { t.ID, t.CustID });
            
            CreateTable(
                "dbo.tbl_DuePayment",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        payment_date = c.String(maxLength: 50, unicode: false),
                        invoice_id = c.Long(),
                        total_amount = c.Decimal(precision: 18, scale: 2),
                        due_amount = c.Decimal(precision: 18, scale: 2),
                        paid_amount = c.Decimal(precision: 18, scale: 2),
                        payment_type = c.String(unicode: false),
                        customer_id = c.String(unicode: false),
                        status = c.Int(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.tbl_Expense",
                c => new
                    {
                        id = c.Long(nullable: false),
                        category_id = c.Long(nullable: false),
                        expense_date = c.String(unicode: false),
                        reference_no = c.String(unicode: false),
                        amount = c.Decimal(precision: 18, scale: 2),
                        note = c.String(unicode: false),
                        created_by = c.String(unicode: false),
                    })
                .PrimaryKey(t => new { t.id, t.category_id });
            
            CreateTable(
                "dbo.tbl_ExpenseGroup",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        group_name = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.tbl_HoldNo",
                c => new
                    {
                        auto_id = c.Long(nullable: false, identity: true),
                        hold_id = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.auto_id);
            
            CreateTable(
                "dbo.tbl_InvoiceDetail",
                c => new
                    {
                        detail_id = c.Long(nullable: false, identity: true),
                        header_id = c.Long(),
                        invoice_date = c.String(unicode: false),
                        invoice_time = c.String(unicode: false),
                        item_code = c.String(maxLength: 150, unicode: false),
                        item_name = c.String(maxLength: 250),
                        qty = c.Decimal(precision: 18, scale: 2),
                        selling_price = c.Decimal(precision: 18, scale: 2),
                        total = c.Decimal(precision: 18, scale: 2),
                        discount = c.Decimal(precision: 18, scale: 2),
                        discount_amount = c.Decimal(precision: 18, scale: 2),
                        net_amount = c.Decimal(precision: 18, scale: 2),
                        profit = c.Decimal(precision: 18, scale: 2),
                        tax_apply = c.Boolean(),
                        show_kitchen = c.Boolean(),
                        log_date = c.DateTime(),
                    })
                .PrimaryKey(t => t.detail_id);
            
            CreateTable(
                "dbo.tbl_InvoiceHeader",
                c => new
                    {
                        invoice_id = c.Long(nullable: false, identity: true),
                        order_type = c.Int(),
                        invoice_no = c.String(unicode: false),
                        invoice_date = c.String(unicode: false),
                        invoice_time = c.String(unicode: false),
                        table_id = c.Long(),
                        no_of_guests = c.Long(),
                        waiter_id = c.Long(),
                        customer_id = c.String(nullable: false, unicode: false),
                        payment_type = c.String(nullable: false, unicode: false),
                        payment_amount = c.Decimal(precision: 18, scale: 2),
                        paid_amount = c.Decimal(precision: 18, scale: 2),
                        change_amount = c.Decimal(precision: 18, scale: 2),
                        due_amount = c.Decimal(precision: 18, scale: 2),
                        discount_rate = c.Decimal(precision: 18, scale: 2),
                        discount_amount = c.Decimal(precision: 18, scale: 2),
                        tax1_name = c.String(),
                        tax1_rate = c.Decimal(precision: 18, scale: 2),
                        tax1_amount = c.Decimal(precision: 18, scale: 2),
                        tax2_name = c.String(),
                        tax2_rate = c.Decimal(precision: 18, scale: 2),
                        tax2_amount = c.Decimal(precision: 18, scale: 2),
                        sc_rate = c.Decimal(precision: 18, scale: 2),
                        sc_charge = c.Decimal(precision: 18, scale: 2),
                        note = c.String(),
                        user_name = c.String(nullable: false, unicode: false),
                        log_date = c.DateTime(),
                    })
                .PrimaryKey(t => t.invoice_id);
            
            CreateTable(
                "dbo.tbl_InvoiceNo",
                c => new
                    {
                        auto_id = c.Long(nullable: false, identity: true),
                        invoice_no = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.auto_id);
            
            CreateTable(
                "dbo.tbl_Item",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        item_code = c.String(unicode: false),
                        item_name = c.String(),
                        cost_price = c.Decimal(precision: 18, scale: 2),
                        selling_price = c.Decimal(precision: 18, scale: 2),
                        discount = c.Decimal(precision: 18, scale: 2),
                        category_id = c.Long(),
                        image_name = c.String(unicode: false),
                        tax_apply = c.Boolean(),
                        show_kitchen = c.Boolean(),
                        print_kot = c.Boolean(),
                        show_pos = c.Boolean(),
                        stock_item = c.Boolean(),
                        reorder_level = c.Decimal(precision: 18, scale: 2),
                        active = c.Boolean(),
                        stock_quantity = c.Decimal(precision: 18, scale: 2),
                        sort_order = c.Long(),
                        log_date = c.DateTime(),
                        update_date = c.DateTime(),
                        update_by = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.tbl_ItemNo",
                c => new
                    {
                        auto_id = c.Long(nullable: false, identity: true),
                        item_no = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.auto_id);
            
            CreateTable(
                "dbo.tbl_KotNo",
                c => new
                    {
                        auto_id = c.Long(nullable: false, identity: true),
                        kot_no = c.String(unicode: false),
                        hold_id = c.Long(),
                    })
                .PrimaryKey(t => t.auto_id);
            
            CreateTable(
                "dbo.tbl_Modifier",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        name = c.String(unicode: false),
                        price = c.Decimal(precision: 18, scale: 2),
                        price_method = c.String(maxLength: 1, unicode: false),
                        item_code = c.String(unicode: false),
                        print_to_kitchen = c.Boolean(),
                        back_color = c.String(unicode: false),
                        fore_color = c.String(unicode: false),
                        sort_order = c.Long(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.tbl_PaymentType",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        payment_type = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.tbl_Purchase",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        purchase_date = c.String(unicode: false),
                        ref_no = c.String(unicode: false),
                        supplier_id = c.Long(),
                        product_id = c.Long(),
                        quantity = c.Decimal(precision: 18, scale: 2),
                        price = c.Decimal(precision: 18, scale: 2),
                        amount = c.Decimal(precision: 18, scale: 2),
                        purchase_type = c.String(unicode: false),
                        status = c.Int(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.tbl_ReturnItem",
                c => new
                    {
                        return_id = c.Long(nullable: false, identity: true),
                        return_date = c.String(unicode: false),
                        invoice_no = c.String(unicode: false),
                        customer_id = c.String(unicode: false),
                        item_code = c.String(unicode: false),
                        item_name = c.String(unicode: false),
                        qty = c.Decimal(precision: 18, scale: 2),
                        price = c.Decimal(precision: 18, scale: 2),
                        total = c.Decimal(precision: 18, scale: 2),
                        discount_rate = c.Decimal(precision: 18, scale: 2),
                        discount_amount = c.Decimal(precision: 18, scale: 2),
                        tax1_name = c.String(),
                        tax1_rate = c.Decimal(precision: 18, scale: 2),
                        tax1_amount = c.Decimal(precision: 18, scale: 2),
                        tax2_name = c.String(),
                        tax2_rate = c.Decimal(precision: 18, scale: 2),
                        tax2_amount = c.Decimal(precision: 18, scale: 2),
                        note = c.String(maxLength: 250),
                        user_name = c.String(),
                        logdate = c.DateTime(),
                    })
                .PrimaryKey(t => t.return_id);
            
            CreateTable(
                "dbo.tbl_Supplier",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        name = c.String(unicode: false),
                        address = c.String(unicode: false),
                        phone = c.String(unicode: false),
                        email = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.tbl_TableLocation",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        location_name = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tbl_Tables",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        table_name = c.String(unicode: false),
                        no_of_chairs = c.Long(),
                        location_id = c.Long(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.tbl_TempDetail",
                c => new
                    {
                        detail_id = c.Long(nullable: false, identity: true),
                        header_id = c.Long(),
                        invoice_date = c.String(unicode: false),
                        invoice_time = c.String(unicode: false),
                        item_code = c.String(maxLength: 150, unicode: false),
                        item_name = c.String(maxLength: 250),
                        qty = c.Decimal(precision: 18, scale: 0),
                        selling_price = c.Decimal(precision: 18, scale: 2),
                        total = c.Decimal(precision: 18, scale: 2),
                        discount = c.Decimal(precision: 18, scale: 2),
                        discount_amount = c.Decimal(precision: 18, scale: 2),
                        net_amount = c.Decimal(precision: 18, scale: 2),
                        profit = c.Decimal(precision: 18, scale: 2),
                        tax_apply = c.Boolean(),
                        show_kitchen = c.Boolean(),
                        print_kot = c.Boolean(),
                        kot_qty = c.Long(),
                        log_date = c.DateTime(),
                    })
                .PrimaryKey(t => t.detail_id);
            
            CreateTable(
                "dbo.tbl_TempHeader",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        order_type = c.Int(),
                        invoice_date = c.String(unicode: false),
                        invoice_time = c.String(unicode: false),
                        kot_no = c.String(unicode: false),
                        table_id = c.Long(),
                        no_of_guests = c.Long(),
                        waiter_id = c.Long(),
                        customer_id = c.String(nullable: false, unicode: false),
                        payment_type = c.String(nullable: false, unicode: false),
                        payment_amount = c.Decimal(precision: 18, scale: 2),
                        paid_amount = c.Decimal(precision: 18, scale: 2),
                        change_amount = c.Decimal(precision: 18, scale: 2),
                        due_amount = c.Decimal(precision: 18, scale: 2),
                        discount_rate = c.Decimal(precision: 18, scale: 2),
                        discount_amount = c.Decimal(precision: 18, scale: 2),
                        tax1_name = c.String(),
                        tax1_rate = c.Decimal(precision: 18, scale: 2),
                        tax1_amount = c.Decimal(precision: 18, scale: 2),
                        tax2_name = c.String(),
                        tax2_rate = c.Decimal(precision: 18, scale: 2),
                        tax2_amount = c.Decimal(precision: 18, scale: 2),
                        sc_rate = c.Decimal(precision: 18, scale: 2),
                        sc_charge = c.Decimal(precision: 18, scale: 2),
                        note = c.String(),
                        user_name = c.String(nullable: false, unicode: false),
                        status = c.String(unicode: false),
                        log_date = c.DateTime(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.tbl_TerminalLocation",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(maxLength: 250, unicode: false),
                        Branchname = c.String(maxLength: 150, unicode: false),
                        Location = c.String(maxLength: 430, unicode: false),
                        Phone = c.String(maxLength: 50, unicode: false),
                        Email = c.String(maxLength: 150, unicode: false),
                        Web = c.String(maxLength: 150, unicode: false),
                        VAT = c.Decimal(precision: 18, scale: 3),
                        Dis = c.Decimal(precision: 18, scale: 3),
                        VATRegiNo = c.String(maxLength: 150, unicode: false),
                        Shopid = c.String(maxLength: 110, unicode: false),
                        Footermsg = c.String(maxLength: 450, unicode: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.tbl_User",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        name = c.String(unicode: false),
                        address = c.String(unicode: false),
                        contact = c.String(unicode: false),
                        email = c.String(unicode: false),
                        dob = c.String(unicode: false),
                        user_name = c.String(unicode: false),
                        password = c.String(unicode: false),
                        user_type = c.String(unicode: false),
                        image_name = c.String(unicode: false),
                        log_date = c.DateTime(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.tbl_UserLogs",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        user_name = c.String(maxLength: 150, unicode: false),
                        log_type = c.String(maxLength: 50, unicode: false),
                        log_date = c.DateTime(storeType: "date"),
                        log_time = c.Time(precision: 0),
                        status = c.Int(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.vw_CustCreditReport",
                c => new
                    {
                        TrxID = c.Long(nullable: false),
                        Date = c.String(maxLength: 150, unicode: false),
                        CustID = c.Long(),
                        Name = c.String(maxLength: 250, unicode: false),
                        OrderID = c.String(maxLength: 250, unicode: false),
                        Credit = c.Decimal(precision: 18, scale: 2),
                        Description = c.String(maxLength: 250, unicode: false),
                    })
                .PrimaryKey(t => t.TrxID);
            
            CreateTable(
                "dbo.vw_CustomerCredit",
                c => new
                    {
                        ID = c.Long(nullable: false),
                        Name = c.String(maxLength: 250, unicode: false),
                        Mobile = c.String(maxLength: 50, unicode: false),
                        Address = c.String(maxLength: 250, unicode: false),
                        EmailAddress = c.String(maxLength: 250, unicode: false),
                        City = c.String(maxLength: 50, unicode: false),
                        PeopleType = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.vw_General_Ledger",
                c => new
                    {
                        Return = c.Decimal(nullable: false, precision: 38, scale: 2),
                        Date = c.String(maxLength: 150, unicode: false),
                        Sales = c.Decimal(precision: 38, scale: 2),
                    })
                .PrimaryKey(t => t.Return);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.vw_General_Ledger");
            DropTable("dbo.vw_CustomerCredit");
            DropTable("dbo.vw_CustCreditReport");
            DropTable("dbo.tbl_UserLogs");
            DropTable("dbo.tbl_User");
            DropTable("dbo.tbl_TerminalLocation");
            DropTable("dbo.tbl_TempHeader");
            DropTable("dbo.tbl_TempDetail");
            DropTable("dbo.tbl_Tables");
            DropTable("dbo.tbl_TableLocation");
            DropTable("dbo.tbl_Supplier");
            DropTable("dbo.tbl_ReturnItem");
            DropTable("dbo.tbl_Purchase");
            DropTable("dbo.tbl_PaymentType");
            DropTable("dbo.tbl_Modifier");
            DropTable("dbo.tbl_KotNo");
            DropTable("dbo.tbl_ItemNo");
            DropTable("dbo.tbl_Item");
            DropTable("dbo.tbl_InvoiceNo");
            DropTable("dbo.tbl_InvoiceHeader");
            DropTable("dbo.tbl_InvoiceDetail");
            DropTable("dbo.tbl_HoldNo");
            DropTable("dbo.tbl_ExpenseGroup");
            DropTable("dbo.tbl_Expense");
            DropTable("dbo.tbl_DuePayment");
            DropTable("dbo.tbl_CustomerCredit");
            DropTable("dbo.tbl_Customer");
            DropTable("dbo.tbl_Company");
            DropTable("dbo.tbl_Category");
        }
    }
}
