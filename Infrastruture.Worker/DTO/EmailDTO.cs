﻿using MailKit;

namespace Infrastruture.Worker.DTO
{
    public  class EmailDTO
    {
        public string EmailSubject { get; set; }
        public string EmailText { get; set; }
        public string To { get; set; }
        public byte [] File { get; set; }
    }
}
