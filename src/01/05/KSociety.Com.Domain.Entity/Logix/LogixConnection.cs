﻿using System;

namespace KSociety.Com.Domain.Entity.Logix
{
    public class LogixConnection : Common.Connection
    {
        public byte[] Path { get; private set; }

        public LogixConnection(
            byte[] path
        )
        {
            Path = path;

        }

        public LogixConnection(
            string path
        )
        {

            Path = StringPathConverter(path);
        }

        public LogixConnection(
            int automationTypeId,
            string name,
            string ip,
            bool enable,
            bool writeEnable,
            byte[] path
        )
            : base(
                automationTypeId,
                name,
                ip,
                enable,
                writeEnable
            )
        {
            Path = path;
        }

        public LogixConnection(
            int automationTypeId,
            string name,
            string ip,
            bool enable,
            bool writeEnable,
            string path
        )
            : base(
                automationTypeId,
                name,
                ip,
                enable,
                writeEnable
            )
        {
            Path = StringPathConverter(path);
        }

        public LogixConnection(
            Guid id,
            int automationTypeId,
            string name,
            string ip,
            bool enable,
            bool writeEnable,
            byte[] path
        )
            : base(
                id,
                automationTypeId,
                name,
                ip,
                enable,
                writeEnable
            )
        {
            Path = path;
        }

        public LogixConnection(
            Guid id,
            int automationTypeId,
            string name,
            string ip,
            bool enable,
            bool writeEnable,
            string path
        )
            : base(
                id,
                automationTypeId,
                name,
                ip,
                enable,
                writeEnable
            )
        {
            Path = StringPathConverter(path);
        }

        private static byte[] StringPathConverter(string path)
        {
            string[] splitResult = path.Split('-');

            byte[] pathArray = new byte[splitResult.Length];

            for (int i = 0; i < splitResult.Length; i++)
            {
                pathArray[i] = Convert.ToByte(splitResult[i], 16);
            }

            return pathArray;
        }

        public override void Initiate()
        {

        }
    }
}