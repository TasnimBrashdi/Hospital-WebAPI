﻿using Hospital.Models;

namespace Hospital.Services
{
    public interface IBookingService
    {
        void AddBooking(Booking bookings,Clinic clinic);
        List<Booking> GetBookingByIdClinic(int id);
        List<Booking> GetBookingByIdPatient(int id);
        List<Booking> GetByName(string name);
    }
}