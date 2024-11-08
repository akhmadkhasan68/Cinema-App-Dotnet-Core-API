using CinemaApp.Dtos.Transaction;
using CinemaApp.Models;

namespace CinemaApp.Mappers
{
    public static class TransactionMapper
    {
        public static TransactionDto ToDto(this Transaction transaction)
        {
            return new TransactionDto
            {
                Id = transaction.Id,
                TicketId = transaction.TicketId,
                PaymentMethodId = transaction.PaymentMethodId,
                Status = transaction.Status,
                Ticket = transaction.Ticket?.ToDto() ?? null,
                PaymentMethod = transaction.PaymentMethod?.ToDto() ?? null,
                CreatedAt = transaction.CreatedAt,
                UpdatedAt = transaction.UpdatedAt,
            };
        }   

        public static TransactionResponseDto ToResponse(this TransactionDto transactionDto)
        {
            return new TransactionResponseDto
            {
                Id = transactionDto.Id,
                Ticket = transactionDto.Ticket?.ToResponse() ?? null,
                PaymentMethod = transactionDto.PaymentMethod?.ToResponse() ?? null,
                Status = transactionDto.Status,
                CreatedAt = transactionDto.CreatedAt,
                UpdatedAt = transactionDto.UpdatedAt,
            };
        }     
    }
}
