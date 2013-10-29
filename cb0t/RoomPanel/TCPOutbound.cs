﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cb0t
{
    class TCPOutbound
    {
        public static byte[] Login()
        {
            String str;
            TCPPacketWriter packet = new TCPPacketWriter();
            packet.WriteGuid(Settings.Guid);
            packet.WriteUInt16(0);
            packet.WriteByte((byte)Settings.GetReg<int>("crypto", 250));
            packet.WriteUInt16(220);
            //packet.WriteIP("0.0.0.0");
            packet.WriteBytes(new byte[] { 0x7b, 0xff, 0x7b, 0xff });
            packet.WriteUInt16(65535);
            packet.WriteUInt32(0);
            packet.WriteString("n-oobe", true);
            packet.WriteString("cb0t 3.00a", true);
            packet.WriteIP(Settings.LocalIP);
            packet.WriteIP(Settings.LocalIP);
            packet.WriteByte(7);
            packet.WriteBytes(new byte[] { 0, 0, 0 });
            packet.WriteByte((byte)Settings.GetReg<int>("user_age", 0));
            packet.WriteByte((byte)Settings.GetReg<int>("user_gender", 0));
            packet.WriteByte((byte)Settings.GetReg<int>("user_country", 0));
            str = Settings.GetReg<String>("user_region", String.Empty);

            if (str.Length > 30)
                str = str.Substring(0, 30);

            packet.WriteString(str);
            packet.WriteByte((byte)(1 | 2 | 4 | 8));
            return packet.ToAresPacket(TCPMsg.MSG_CHAT_CLIENT_LOGIN);
        }

        public static byte[] Update(CryptoService c)
        {
            String str;
            TCPPacketWriter packet = new TCPPacketWriter();
            packet.WriteUInt16(0);
            packet.WriteByte(7);
            packet.WriteIP("0.0.0.0");
            packet.WriteUInt16(65535);
            packet.WriteIP(Settings.LocalIP);
            packet.WriteByte((byte)Settings.GetReg<int>("user_age", 0));
            packet.WriteByte((byte)Settings.GetReg<int>("user_gender", 0));
            packet.WriteByte((byte)Settings.GetReg<int>("user_country", 0));
            str = Settings.GetReg<String>("user_region", String.Empty);

            if (str.Length > 30)
                str = str.Substring(0, 30);

            packet.WriteString(str, c);
            return packet.ToAresPacket(TCPMsg.MSG_CHAT_CLIENT_UPDATE_STATUS);
        }

        public static byte[] Public(String text, CryptoService c)
        {
            TCPPacketWriter packet = new TCPPacketWriter();
            packet.WriteString(Helpers.FormatAresColorCodes(text), c, false);
            return packet.ToAresPacket(TCPMsg.MSG_CHAT_CLIENT_PUBLIC);
        }

        public static byte[] Emote(String text, CryptoService c)
        {
            TCPPacketWriter packet = new TCPPacketWriter();
            packet.WriteString(Helpers.FormatAresColorCodes(text), c, false);
            return packet.ToAresPacket(TCPMsg.MSG_CHAT_CLIENT_EMOTE);
        }

        public static byte[] Command(String text, CryptoService c)
        {
            TCPPacketWriter packet = new TCPPacketWriter();
            packet.WriteString(Helpers.FormatAresColorCodes(text), c, false);
            return packet.ToAresPacket(TCPMsg.MSG_CHAT_CLIENT_COMMAND);
        }

        public static byte[] Lag(String name, ulong time, CryptoService c)
        {
            TCPPacketWriter packet = new TCPPacketWriter();
            packet.WriteString("cb0t_latency_check", c);
            packet.WriteString(name, c);
            packet.WriteUInt64(time);
            return packet.ToAresPacket(TCPMsg.MSG_CHAT_CLIENT_CUSTOM_DATA);
        }

        public static byte[] ManualLag(String name, ulong time, CryptoService c)
        {
            TCPPacketWriter packet = new TCPPacketWriter();
            packet.WriteString("cb0t_latency_mcheck", c);
            packet.WriteString(name, c);
            packet.WriteUInt64(time);
            return packet.ToAresPacket(TCPMsg.MSG_CHAT_CLIENT_CUSTOM_DATA);
        }

        public static byte[] Writing(bool writing, CryptoService c)
        {
            TCPPacketWriter packet = new TCPPacketWriter();
            packet.WriteString("cb0t_writing", c);
            packet.WriteByte((byte)(writing ? 2 : 1));
            return packet.ToAresPacket(TCPMsg.MSG_CHAT_CLIENT_CUSTOM_DATA_ALL);
        }

        public static byte[] Nudge(String myName, String target, CryptoService c)
        {
            byte[] temp = Encoding.UTF8.GetBytes("0" + myName);
            temp = Hashlink.e67(temp, 0x5d0);
            temp = Encoding.Default.GetBytes(Convert.ToBase64String(temp));
            TCPPacketWriter packet = new TCPPacketWriter();
            packet.WriteString("cb0t_nudge", c);
            packet.WriteString(target, c);
            packet.WriteBytes(temp);
            return packet.ToAresPacket(TCPMsg.MSG_CHAT_CLIENT_CUSTOM_DATA);
        }

        public static byte[] NudgeReject(String target, CryptoService c)
        {
            TCPPacketWriter packet = new TCPPacketWriter();
            packet.WriteString("cb0t_nudge", c);
            packet.WriteString(target, c);
            packet.WriteBytes(new byte[] { 78, 65, 61, 61 });
            return packet.ToAresPacket(TCPMsg.MSG_CHAT_CLIENT_CUSTOM_DATA);
        }

        public static byte[] Private(String name, String text, CryptoService c)
        {
            TCPPacketWriter packet = new TCPPacketWriter();
            packet.WriteString(name, c);
            packet.WriteString(Helpers.FormatAresColorCodes(text), c, false);
            return packet.ToAresPacket(TCPMsg.MSG_CHAT_CLIENT_PVT);
        }

        public static byte[] CustomPM(String target, String text, CryptoService c)
        {
            TCPPacketWriter packet = new TCPPacketWriter();
            packet.WriteString("cb0t_pm_msg", c);
            packet.WriteString(target, c);
            packet.WriteBytes(PMCrypto.SoftEncrypt(target, Encoding.UTF8.GetBytes(Helpers.FormatAresColorCodes(text))));
            return packet.ToAresPacket(TCPMsg.MSG_CHAT_CLIENT_CUSTOM_DATA);
        }

        public static byte[] Ignore(String name, bool ignore, CryptoService c)
        {
            TCPPacketWriter packet = new TCPPacketWriter();
            packet.WriteByte((byte)(ignore ? 1 : 0));
            packet.WriteString(name, c);
            return packet.ToAresPacket(TCPMsg.MSG_CHAT_CLIENT_IGNORELIST);
        }

        public static byte[] Browse(String target, ushort ident, CryptoService c)
        {
            TCPPacketWriter packet = new TCPPacketWriter();
            packet.WriteUInt16(ident);
            packet.WriteByte(0);
            packet.WriteString(target, c);
            return packet.ToAresPacket(TCPMsg.MSG_CHAT_CLIENT_BROWSE);
        }


    }
}
