using Focu.Api.Data;
using Focu.Core.Handlers;
using Focu.Core.Models;
using Focu.Core.Requests.Orders;
using Focu.Core.Responses;
using Microsoft.EntityFrameworkCore;

namespace Focu.Api.Handlers;

public class VoucherHandler(AppDbContext context) : IVoucherHandler
{
    public async Task<Response<Voucher?>> GetByNumberAsync(GetVoucherByNumberRequest request)
    {
        var voucher = await context
            .Vouchers
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Number == request.Number && x.IsActive == true);

        return voucher is null
            ? new Response<Voucher?>(null, StatusCodes.Status404NotFound, "Voucher not found")
            : new Response<Voucher?>(voucher);
    }
}

