# General Scaffold Template
dotnet ef dbcontext scaffold "Server=.;Database=BlogDB;User Id=sa;Password=sasa@123;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -o Models -c AppDbContext -t Tbl_Blog -f


dotnet ef dbcontext scaffold "Server=.;Database=BlogDB;User Id=sa;Password=sasa@123;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer -o Models -c AppDbContext --force --tables TblStudent
