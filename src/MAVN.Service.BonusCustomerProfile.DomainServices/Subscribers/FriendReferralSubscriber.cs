﻿using Lykke.Common.Log;
using MAVN.Service.BonusCustomerProfile.Domain.Services;
using System;
using System.Threading.Tasks;
using Common.Log;
using MAVN.Service.Referral.Contract.Events;

namespace MAVN.Service.BonusCustomerProfile.DomainServices.Subscribers
{
    public class FriendReferralSubscriber :
        RabbitSubscriber<FriendReferralEvent>
    {
        private readonly ICustomerProfileService _customerProfileService;
        private readonly ILog _log;

        public FriendReferralSubscriber(
            string connectionString,
            string exchangeName,
            ILogFactory logFactory,
            ICustomerProfileService customerProfileService)
            : base(connectionString, exchangeName, logFactory)
        {
            _customerProfileService = customerProfileService 
                                      ?? throw new ArgumentNullException(nameof(customerProfileService));
            _log = logFactory.CreateLog(this);

            GuidsFieldsToValidate.Add(nameof(FriendReferralEvent.ReferrerId));
        }

        public override async Task<(bool isSuccessful, string errorMessage)> ProcessMessageAsync(FriendReferralEvent message)
        {
            await _customerProfileService.ProcessFriendReferralEvent(Guid.Parse(message.ReferrerId));

            return (true, string.Empty);
        }
    }
}
