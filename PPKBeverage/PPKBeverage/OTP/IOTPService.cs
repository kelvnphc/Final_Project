using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PPKBeverage.OTP
{
    public interface IOtpService
    {
        // Định nghĩa các phương thức mà OtpService sẽ triển khai
        string GenerateOtp();
        void SendOtp(string toPhoneNumber);
    }
}

