using AutoMapper;
using MovieStore.Business.Abstract;
using MovieStore.Core.Entity;
using MovieStore.Core.Model.Request.Order;
using MovieStore.Core.Model;
using MovieStore.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MovieStore.DataAccess.Concrete;

namespace MovieStore.Business.Concrete
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<Order>> Create(OrderCreateRequest orderCreateRequest)
        {
            Order order = _mapper.Map<Order>(orderCreateRequest);
            var resultOrder = await _orderRepository.Create(order);

            return resultOrder;

        }

        public async Task<BaseResponse<Order>> Delete(int Id)
        {
            var result = await _orderRepository.Get(x => x.Id == Id);
            return await _orderRepository.Delete(result.Data);
        }

        public async Task<BaseResponse<Order>> Get(Expression<Func<Order, bool>> filter)
        {
            return await _orderRepository.Get(filter);

        }

        public async Task<BaseResponse<List<Order>>> GetAllByFilter(Expression<Func<Order, bool>> filter)
        {
            return await _orderRepository.GetList(filter);
        }
        public async Task<BaseResponse<List<Order>>> Getlist()
        {
            return await _orderRepository.GetAll();
        }

        public Task<BaseResponse<Order>> Update(OrderUpdateRequest orderUpdateRequest) ///????
        {
            Order order = _mapper.Map<Order>(orderUpdateRequest);
            return _orderRepository.Update(order);
        }
    }
}
