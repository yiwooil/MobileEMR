using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MEE
{
    class CDCcfValue
    {
        private String field;
        private float x;
	    private float y;
        private float w;
        private float h;
        private String autoFit;

        public CDCcfValue(String field, float x, float y, float w, float h, String autoFit)
        {
            this.field=field;
		    this.x = x;
		    this.y = y;
            this.w = w;
            this.h = h;
            this.autoFit = autoFit;
	    }

        public String getField()
        {
            return field;
        }

	    public float getX(){
		    return this.x;
	    }
    	
	    public float getY(){
		    return this.y;
	    }

        public float getW()
        {
            return this.w;
        }

        public float getH()
        {
            return this.h;
        }

        public String getAutoFit()
        {
            return autoFit;
        }
    }
}
