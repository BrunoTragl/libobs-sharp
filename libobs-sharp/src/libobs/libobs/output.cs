/***************************************************************************
	Copyright (C) 2014-2015 by Ari Vuollet <ari.vuollet@kapsi.fi>

	This program is free software; you can redistribute it and/or
	modify it under the terms of the GNU General Public License
	as published by the Free Software Foundation; either version 2
	of the License, or (at your option) any later version.

	This program is distributed in the hope that it will be useful,
	but WITHOUT ANY WARRANTY; without even the implied warranty of
	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
	GNU General Public License for more details.

	You should have received a copy of the GNU General Public License
	along with this program; if not, see <http://www.gnu.org/licenses/>.
***************************************************************************/

using System;
using System.Runtime.InteropServices;

namespace OBS
{
    using obs_data_t = IntPtr;
    using size_t = UIntPtr;

    using obs_output_t = IntPtr;
    using obs_encoder_t = IntPtr;

    public static partial class libobs
	{
        /* ------------------------------------------------------------------------- */
        /* Outputs */

        //EXPORT const char *obs_output_get_display_name(const char *id);

        [DllImport(importLibrary, CallingConvention = importCall, CharSet = importCharSet)]
        public static extern obs_output_t obs_output_create(
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8StringMarshaler))] string id,
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(UTF8StringMarshaler))] string name, 
            obs_data_t settings, obs_data_t hotkey_data);

        //EXPORT void obs_output_destroy(obs_output_t *output);
        //EXPORT const char *obs_output_get_name(const obs_output_t *output);

        [DllImport(importLibrary, CallingConvention = importCall)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool obs_output_start(obs_output_t output);

        [DllImport(importLibrary, CallingConvention = importCall)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool obs_output_stop(obs_output_t output);

        [DllImport(importLibrary, CallingConvention = importCall)]
        public static extern void obs_output_release(obs_output_t output);

        [DllImport(importLibrary, CallingConvention = importCall)]
        public static extern void obs_output_addref(obs_output_t output);

		//EXPORT void obs_output_set_delay(obs_output_t *output, uint32_t delay_sec, uint32_t flags);
		//EXPORT uint32_t obs_output_get_delay(const obs_output_t *output);
		//EXPORT uint32_t obs_output_get_active_delay(const obs_output_t *output);
		//EXPORT void obs_output_force_stop(obs_output_t *output);
		//EXPORT bool obs_output_active(const obs_output_t *output);
		//EXPORT obs_data_t *obs_output_defaults(const char *id);
		//EXPORT obs_properties_t *obs_get_output_properties(const char *id);
		//EXPORT obs_properties_t *obs_output_properties(const obs_output_t *output);

		[DllImport(importLibrary, CallingConvention = importCall)]
		public static extern void obs_output_update(obs_output_t encoder, obs_data_t settings);

		//EXPORT bool obs_output_can_pause(const obs_output_t *output);

		[DllImport(importLibrary, CallingConvention = importCall)]
		public static extern void obs_output_pause(obs_output_t output);

		//EXPORT obs_data_t *obs_output_get_settings(const obs_output_t *output);
		//EXPORT signal_handler_t *obs_output_get_signal_handler(
		//EXPORT proc_handler_t *obs_output_get_proc_handler(const obs_output_t *output);
		//EXPORT void obs_output_set_video(obs_output_t *output, video_t *video);
		//EXPORT void obs_output_set_media(obs_output_t *output, video_t *video, audio_t *audio);
		//EXPORT video_t *obs_output_video(const obs_output_t *output);
		//EXPORT audio_t *obs_output_audio(const obs_output_t *output);
		//EXPORT void obs_output_set_mixer(obs_output_t *output, size_t mixer_idx);
		//EXPORT size_t obs_output_get_mixer(const obs_output_t *output);



		[DllImport(importLibrary, CallingConvention = importCall)]
        public static extern void obs_output_set_video_encoder(obs_output_t output, obs_encoder_t encoder);

        [DllImport(importLibrary, CallingConvention = importCall)]
        public static extern void obs_output_set_audio_encoder(obs_output_t output, obs_encoder_t encoder, size_t idx);



        //EXPORT obs_encoder_t *obs_output_get_video_encoder(const obs_output_t *output);
        //EXPORT obs_encoder_t *obs_output_get_audio_encoder(const obs_output_t *output, size_t idx);
        //EXPORT void obs_output_set_service(obs_output_t *output, obs_service_t *service);
        //EXPORT obs_service_t *obs_output_get_service(const obs_output_t *output);
        //EXPORT void obs_output_set_reconnect_settings(obs_output_t *output, int retry_count, int retry_sec);
        //EXPORT uint64_t obs_output_get_total_bytes(const obs_output_t *output);
        //EXPORT int obs_output_get_frames_dropped(const obs_output_t *output);
        //EXPORT int obs_output_get_total_frames(const obs_output_t *output);
        //EXPORT void obs_output_set_preferred_size(obs_output_t *output, uint32_t width, uint32_t height);
        //EXPORT uint32_t obs_output_get_width(const obs_output_t *output);
        //EXPORT uint32_t obs_output_get_height(const obs_output_t *output);
        //EXPORT const char *obs_output_get_id(const obs_output_t *output);

        /* ------------------------------------------------------------------------- */
        /* Functions used by outputs */

        //EXPORT void *obs_output_get_type_data(obs_output_t *output);

        //EXPORT void obs_output_set_video_conversion(obs_output_t *output, const struct video_scale_info *conversion);
        //EXPORT void obs_output_set_audio_conversion(obs_output_t *output, const struct audio_convert_info *conversion);
        //EXPORT bool obs_output_can_begin_data_capture(const obs_output_t *output, uint32_t flags);
        //EXPORT bool obs_output_initialize_encoders(obs_output_t *output, uint32_t flags);
        //EXPORT bool obs_output_begin_data_capture(obs_output_t *output, uint32_t flags);
        //EXPORT void obs_output_end_data_capture(obs_output_t *output);
        //EXPORT void obs_output_signal_stop(obs_output_t *output, int code);
    }
}