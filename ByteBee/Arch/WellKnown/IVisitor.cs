﻿// ReSharper disable UnusedMember.Global
namespace ByteBee.Arch.WellKnown
{
    public interface IVisitor<in TEntity>
    {
        void Visit(TEntity source);
    }
}